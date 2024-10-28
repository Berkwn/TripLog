import { TagModel } from "./Tag.model";
import { TripContentModel } from "./Trip-Content";

export class UpdateTripModel{
id:number=0;
title:string="";
 description:string="";
 tags:string="";
 image:any=null;
 imageUrl:string="";
 createdDate:string="";
tripContents:TripContentModel[]=[];
}