import { Component, Input } from '@angular/core';
import { CreateTripContentModel } from '../../models/create-trip-content.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-trip-content',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './trip-content.component.html',
  styleUrl: './trip-content.component.css'
})
export class TripContentComponent {
@Input() tripCounter!:number;
title:string="";
description:string="";
image:any=null;



selectedImage(event:any){
  const file= event.target.files[0]

  if(file){
   this.image=file;
  }
}

getTripContentData():CreateTripContentModel{

  return{
    title:this.title,
    description:this.description,
    image:this.image
  }
}
 

}
