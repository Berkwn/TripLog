import Swal  from "sweetalert2";

export class SwalService{ 
    constructor() {}
    callToast(title:string,icon:SweetAlertIcon="info"){
        Swal.fire({
            title:title,
            icon:icon,
            timer:3000,
            showCancelButton:false,
            showConfirmButton:false,
            showCloseButton:false,
        })
        
        }


        callSwal(title:string,text:string,callback:()=>void){
            Swal.fire({
                title:title,
                text:text,
                icon:"question",
                showCloseButton:true,
                cancelButtonText:"Cancel",
                showCancelButton:true,
                showConfirmButton:true,
                confirmButtonText:"DELETE"
            }).then(res=>{
                if(res.isConfirmed){
                    callback();
                }
            })


        }

    }

  export type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'