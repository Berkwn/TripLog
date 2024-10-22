import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { ErrorService } from "./error.service";
import { ResultModel } from "../models/Result.model";
import { api } from "../models/constants";

export class HttpService{
token:string=""
    
  constructor(
    private error:ErrorService,
    private http:HttpClient,

  ) {
    if(localStorage.getItem("token")){
        this.token=localStorage.getItem("token") ?? ""
    }

  }

  post<T>(apiUrl:string,body:any,callback:(res:ResultModel<T>)=>void,errcallback?:(err:HttpErrorResponse)=>void){
    this.http.post(`${api}/${apiUrl}`,body,{
       
    }).subscribe({
        next:(res=>{
            callback(res)
        }),
        error:(err:HttpErrorResponse)=>{
            this.error.errorHandler(err);
            if(errcallback!==undefined){
                errcallback(err)
            }
        }
    })
    
    
}
}