import { CommentModel } from "./comment.model";
import { TagModel } from "./Tag.model";
import { TripContentModel } from "./Trip-Content";
import { UserModel } from "./user.model";

export class TripModel{
id:string="";
title:string="";
 description:string="";
 tags:TagModel[]=[];
 imageUrl:string="";
 appUserId:string="";
 createdDate:string="";
tripContents:TripContentModel[]=[];
appUser:UserModel=new UserModel();
comments:CommentModel[]=[];
}