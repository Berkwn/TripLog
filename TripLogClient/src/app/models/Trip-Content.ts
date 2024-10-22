import { TagModel } from "./Tag.model";

export class TripContentModel{
    id:string="";
    title:string="";
    description:string="";
    ImageUrl:string="";
    tags:TagModel[]=[];
    tripContents:TripContentModel[]=[]
}