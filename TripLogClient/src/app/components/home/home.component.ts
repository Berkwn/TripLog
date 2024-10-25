import { CommonModule } from '@angular/common';
import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { createTripModel } from '../../models/create-trip.model';
import { HttpService } from '../../services/http.service';
import { TripContentComponent } from "../trip-content/trip-content.component";
import { CreateTripContentModel } from '../../models/create-trip-content.model';
import { TripModel } from '../../models/Trip.model';
import { Contentfile, Tripfile } from '../../models/constants';


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
  tripCounter:number=1;
  maxTripCounter:number=10;
  tripContent:number[]=[] 
  constructor(
    private http:HttpService,
  
  ) {
  }


  @ViewChildren(TripContentComponent) tripContentComponent!: QueryList<TripContentComponent> 
  tripModel:TripModel[]=[]
  //getAll yapılacak..



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
    }
  }  


  addTripParts(){
   if(this.tripContent.length < this.tripCounter){
    this.tripContent.push(this.tripCounter)
    this.tripCounter++;
   }
 } 

 FillFromTags(tags:string){

 } 
}
