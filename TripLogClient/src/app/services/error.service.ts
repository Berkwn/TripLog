import { HttpErrorResponse } from "@angular/common/http";
import { SwalService } from "./swal.service";

export class ErrorService{

    /**
     *
     */
    constructor(

        private swal:SwalService

    ) {}
   
    errorHandler(err:HttpErrorResponse){
        console.log(err)
        let message="error"
        if(err.status===401){
            message+=" : You are not Authorized"
        }else if(err.status===404){
            message+= " : Api is not found"
        }else if(err.status===0){
            message+=" :Api is not available"
        } else if (err.status===500){
            message+=" : "
            for(const e of err.error.errorMessage){
                message=e+"\n";
            }
        }
        this.swal.callToast(message,"error")
    }

}