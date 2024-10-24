
import { CreateTripContentModel } from "./create-trip-content.model";


export class createTripModel{
    
    title:string="";
    description:string="";
    image:any=null;
    tags:string="";
    tripContents:CreateTripContentModel[] | null =null;
}