import { UserModel } from "./user.model";

export class CommentModel{
    id:string="";
    text:string="";
    createdDate:string="";
    appUser:UserModel=new UserModel();
}