import { Component, Input } from '@angular/core';
import { CreateTripContentModel } from '../../models/create-trip-content.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UpdateTripContentModel } from '../../models/update-trip-content.model';
import { Contentfile } from '../../models/constants';

@Component({
  selector: 'app-trip-content',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './trip-content.component.html',
  styleUrl: './trip-content.component.css'
})
export class TripContentComponent {
@Input() tripCounter!:number;
id:string=""
title:string="";
description:string="";
image:any=null;
imageUrl:string="";
imagePreview:string | ArrayBuffer | null=null;


selectedImage(event:any){
  const file= event.target.files[0]

  if(file){
   this.image=file;
   this.previewImage(file);
  
  }else{
      this.imagePreview=Contentfile + this.imageUrl;
    
  }
}
previewImage(file:File){
  const reader = new FileReader();
  reader.onload = () =>{
    this.imagePreview = reader.result;
  };
  reader.readAsDataURL(file);
}
getTripContentData():CreateTripContentModel{

  return{
    title:this.title,
    description:this.description,
    image:this.image
  
  }
}

getUpdateTripContentData():UpdateTripContentModel{
  return{
    id:this.id,
    title:this.title,
    description:this.description,
    image:this.image,
    ImageUrl:this.imageUrl
  
  }
}

setValues(id:string,title:string,description:string,imageUrl:string,){
  this.id=id,
  this.title=title;
  this.description=description;
  this.imageUrl=imageUrl
  this.imagePreview="https://localhost:7046/" + imageUrl;
  
}

 

}
