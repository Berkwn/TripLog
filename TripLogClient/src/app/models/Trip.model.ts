import { TagModel } from "./Tag.model";
import { TripContentModel } from "./Trip-Content";

export class TripModel{
id:number=0;
title:string="";
 description:string="";
 tags:TagModel[]=[];
 imageUrl:string="";
tripContents:TripContentModel[]=[];
}