import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";


import { Buyer } from 'src/app/Models/buyer';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-register-buyer',
  templateUrl: './register-buyer.component.html',
  styleUrls: ['./register-buyer.component.css']
})
export class RegisterBuyerComponent implements OnInit {
buyerId:string;
username:string;
password:string;
emailId:string;
mobileNo:number;
createdDateTime:Date;
registerForm:FormGroup;
submitted=false;
list:Buyer[];
item:Buyer;
  constructor(private formbuilder:FormBuilder,private service:AccountService) {
   
   }

  ngOnInit() {
    this.registerForm=this.formbuilder.group({
      
      userName:['',[Validators.required,Validators.pattern('^[a-z0-9A-Z]{3,20}$')]],
      emailId:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.pattern('^[a-zA-Z0-9`!@#$%^&*()_+=]{6,15}$')]],
      mobileNo:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
      createdDateTime:['',Validators.required]
     
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
    this.item=new Buyer();
    this.item.buyerId='B'+Math.floor(Math.random()*1000);
    this.item.userName=this.registerForm.value["userName"];
    this.item.emailId=this.registerForm.value["emailId"];
    this.item.password=this.registerForm.value["password"];
    this.item.mobileNo=this.registerForm.value["mobileNo"];
    this.item.createdDateTime=new Date;
    console.log(this.item);
    this.service.BuyerRegister(this.item).subscribe(res=>{
      console.log('Registered')
    },err=>{
      console.log(err)
    

    })
  }

}
