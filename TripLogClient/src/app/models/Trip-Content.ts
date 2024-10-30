import { TagModel } from "./Tag.model";

export class TripContentModel{
    id:string="";
    title:string="";
    description:string="";
    imageUrl:string="";
    image:string="";
    tags:TagModel[]=[];
    tripContents:TripContentModel[]=[]
}