import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, QueryList, ViewChild, viewChild, ViewChildren } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { createTripModel } from '../../models/create-trip.model';
import { HttpService } from '../../services/http.service';
import { TripContentComponent } from "../trip-content/trip-content.component";
import { CreateTripContentModel } from '../../models/create-trip-content.model';
import { TripModel } from '../../models/Trip.model';
import { Contentfile, Tripfile } from '../../models/constants';
import { UpdateTripModel } from '../../models/update-trip.model';
import { UpdateTripContentModel } from '../../models/update-trip-content.model';
import Swal from 'sweetalert2';
import { SwalService } from '../../services/swal.service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, TripContentComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',

})
export class HomeComponent implements OnInit {
   Tripfile = Tripfile
   ContentFile=Contentfile
  createTripModel:createTripModel=new createTripModel();
  updateTripModel:UpdateTripModel=new UpdateTripModel();
  tripCounter:number=1;
  maxTripCounter:number=10;
  imagePreview:string | ArrayBuffer | null="";
  updateImagePreview:string | ArrayBuffer | null="";

  tripContent:number[]=[]
 
  
  updateTripCounter:number=1;
  updateMaxTripCounter:number=10;
  updatetripContent:number[]=[]

  constructor(
    private http:HttpService,
    private swal:SwalService
  ) {
  }

  @ViewChildren(TripContentComponent) updatetripContentComponent!: QueryList<TripContentComponent> 
  @ViewChildren(TripContentComponent) tripContentComponent!: QueryList<TripContentComponent> 
  @ViewChild("closebtn") closebtn: ElementRef<HTMLButtonElement> | undefined


  tripModel:TripModel[]=[]
  

  previewImage(file:File,type:boolean){
    const reader = new FileReader();
    reader.onload = () =>{
    
   
      if(type){
        this.imagePreview = reader.result;
      } else{
        this.updateImagePreview=reader.result;
      }
    };
    reader.readAsDataURL(file);
 
  }


createTrip(form:NgForm){

  const allTripContent:CreateTripContentModel[]=this.tripContentComponent.map(tripContent=>{
    return tripContent.getTripContentData();
  });

this.createTripModel.tripContents= allTripContent;

  if(form.valid){
    const Formdata= new FormData();
    Formdata.append("title",this.createTripModel.title)
    Formdata.append("description",this.createTripModel.description)
    Formdata.append("image",this.createTripModel.image)
    Formdata.append("tags",this.createTripModel.tags)

    this.createTripModel.tripContents?.forEach((content, index) => {
      Formdata.append(`tripContent[${index}].title`, content.title);
      Formdata.append(`tripContent[${index}].description`, content.description);
      Formdata.append(`tripContent[${index}].image`, content.image); 
      });
    
      console.log(createTripModel)

  

    this.http.post("Trip/Create",Formdata,(res)=>{
      console.log(res.data)
      this.closebtn?.nativeElement.click();
      this.GetAll();
      
    })
    
    
  }

  }

  GetAll(){
    
    this.http.post("Trip/GetAll",{},(res)=>{
      console.log(res.data)
      this.tripModel=res.data;
      console.log(this.tripModel)
    })
  }


ngOnInit(): void {
this.GetAll();
}

  
  selectedImage(event:any){
    const file= event.target.files[0]

    if(file){
     this.createTripModel.image=file;
     
     this.previewImage(file,true);
    }
  }  

  updateSelectedImage(event:any){
    const file= event.target.files[0]

    if(file){
  
     this.updateTripModel.image=file;
     this.previewImage(file,false);
     
    }else{
      this.updateImagePreview=Contentfile + this.updateTripModel.imageUrl;
      this.imagePreview=Contentfile + this.createTripModel.imageUrl;

    
    }
  }  



  addTripParts(){
   if(this.tripContent.length < this.tripCounter){
    this.tripContent.push(this.tripCounter)
    this.tripCounter++;
   }

   
 } 

 addUpdateTripParts(){
  if(this.updatetripContent.length < this.updateTripCounter){
   this.updatetripContent.push(this.updateTripCounter)
   this.updateTripCounter++;

  }

  
} 


 FillFromTags(tags:string){

 } 

updateModal(trip:TripModel){
this.updateTripModel.id=trip.id
this.updateTripModel.title=trip.title;
this.updateTripModel.description=trip.description;
this.updateTripModel.tags=trip.tags.map(x=>x.name).join(" ");
this.updateTripModel.imageUrl=trip.imageUrl;
this.updateImagePreview= Contentfile + trip.imageUrl;

this.updatetripContent=[];
this.updateTripCounter=1;


trip.tripContents.forEach((content,index)=>{
  console.log(trip)
  this.addUpdateTripParts();
    setTimeout(() => {
      const currentComponent =this.updatetripContentComponent.toArray()[index];
      if(currentComponent){
          currentComponent.setValues(content.id,content.title,content.description,content.imageUrl)
      }
    });
})

 }


 closeModal(){
;
  console.log(this.imagePreview)
 }

 updateTrip(form:NgForm){
  if(form.valid){

    const allTripContent:UpdateTripContentModel[]=this.tripContentComponent.map(tripContent=>{
      return tripContent.getUpdateTripContentData();
    });
  
  this.updateTripModel.tripContents= allTripContent;


    const Formdata=new FormData();
    Formdata.append("id",this.updateTripModel.id)
    Formdata.append("title",this.updateTripModel.title)
    Formdata.append("description",this.updateTripModel.description)
    Formdata.append("imageUrl",this.updateTripModel.image)
    Formdata.append("tags",this.updateTripModel.tags)

    this.updateTripModel.tripContents.forEach((content, index) => {
      Formdata.append(`tripContents[${index}].id`, content.id);
      Formdata.append(`tripContents[${index}].title`, content.title);
      Formdata.append(`tripContents[${index}].description`, content.description);
      Formdata.append(`tripContents[${index}].image`, content.image); 
  
      });



    this.http.post("Trip/Update",Formdata,(res)=>{
      console.log(res.data)
      this.closebtn?.nativeElement.click();
      
    })
    
    
  }
  
   }

DeleteTrip(id:string){
this.http.post("Trip/Delete",{id: id},(res)=>{
this.swal.callSwal("delete","are you sure delete",()=>{
  res.data;
  this.GetAll();
})
  

  console.log(res.data)
})

}


  }
 



