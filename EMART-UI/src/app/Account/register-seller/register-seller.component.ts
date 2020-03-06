import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { Seller } from 'src/app/Models/seller';
import { AccountService } from 'src/app/Services/account.service';
@Component({
  selector: 'app-register-seller',
  templateUrl: './register-seller.component.html',
  styleUrls: ['./register-seller.component.css']
})
export class RegisterSellerComponent implements OnInit {
  registerForm:FormGroup;
  submitted=false;
  sellerId:string;
  userName:string;
  emailId:string;
  password:string;
  companyName:string;
  gst:string;
  briefDetails:string;
  postalAddress:string;
  website:string;
  mobileNo:string;
  list:Seller[];
  item:Seller;
  constructor(private formbuilder:FormBuilder,private service:AccountService) { }

  ngOnInit() {
    this.registerForm=this.formbuilder.group({
      sellerId:[''],
     userName:['',[Validators.required,Validators.pattern('^[a-zA-Z]{3,6}$')]],
     emailId:['',[Validators.required,Validators.email]],
     password:['',[Validators.required,Validators.minLength(6)]],
     companyName:['',Validators.required],
     gst:['',Validators.required],
     postalAddress:['',Validators.required],
     mobileNo:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
     
      
    });
  }
  onSubmit()
  {
    this.submitted=true;
    
    this.Add();
}
get f()
{
  return this.registerForm.controls;
}
onReset()
{
this.submitted=false;
this.registerForm.reset();
}
Add()
  {
    this.item=new Seller();
    this.item.sellerId='S'+Math.round(Math.random()*1000);
    this.item.userName=this.registerForm.value["userName"];
    this.item.password=this.registerForm.value["password"];
    this.item.companyName=this.registerForm.value["companyName"];
    this.item.gstin=this.registerForm.value["gst"];
    this.item.briefDetails=this.registerForm.value["briefDetails"];
    this.item.postalAddress=this.registerForm.value["postalAddress"];
    this.item.website=this.registerForm.value["website"];
    this.item.emailId=this.registerForm.value["emailId"];
    this.item.mobileNo=this.registerForm.value["mobileNo"];
    console.log(this.item);
    this.service.SellerRegister(this.item).subscribe(res=>{
      console.log('Registered')
    },err=>{
      console.log(err)
    

    })
  }

}
