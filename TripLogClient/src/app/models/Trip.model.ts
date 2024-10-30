import { TagModel } from "./Tag.model";
import { TripContentModel } from "./Trip-Content";

export class TripModel{
id:string="";
title:string="";
 description:string="";
 tags:TagModel[]=[];
 imageUrl:string="";
 createdDate:string="";
tripContents:TripContentModel[]=[];
}