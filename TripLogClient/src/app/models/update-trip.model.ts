import { TagModel } from "./Tag.model";
import { TripContentModel } from "./Trip-Content";
import { UpdateTripContentModel } from "./update-trip-content.model";

export class UpdateTripModel{
id:string="";
title:string="";
 description:string="";
 tags:string="";
 image:any=null;
 imageUrl:string="";
 createdDate:string="";
tripContents:UpdateTripContentModel[]=[];
}