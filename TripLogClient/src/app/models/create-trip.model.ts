
import { CreateTripContentModel } from "./create-trip-content.model";


export class createTripModel{
    
    title:string="";
    description:string="";
    image:any=null;
    imageUrl:string="";
    tags:string="";
    tripContents:CreateTripContentModel[] | null =null;
}