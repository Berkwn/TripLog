import { TagModel } from "./Tag.model";

export class TripContentModel{
    id:string="";
    title:string="";
    description:string="";
    imageUrl:string="";
    tags:TagModel[]=[];
    tripContents:TripContentModel[]=[]
}