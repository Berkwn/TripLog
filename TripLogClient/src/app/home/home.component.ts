import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { TripModel } from '../models/Trip.model';
import { createTripModel } from '../models/create-trip.model';
import { HttpService } from '../services/http.service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',

})
export class HomeComponent {

  constructor(
    private http:HttpService,
  
  ) {
  }

trips:TripModel[]=[] 
createTripModel:createTripModel=new createTripModel();



createTrip(form:NgForm){
  if(form.valid){
    const Formdata= new FormData();
    Formdata.append("title",this.createTripModel.title)
    Formdata.append("description",this.createTripModel.description)
    Formdata.append("image",this.createTripModel.image)
    Formdata.append("tags",this.createTripModel.tags)
    
    this.http.post("Trip/Create",Formdata,(res)=>{
      console.log(res.data)
    })
    
        console.log(this.createTripModel)
  }

  }

  
  selectedImage(event:any){
    const file= event.target.files[0]

    if(file){
     this.createTripModel.image=file;
    }
  }  
}
