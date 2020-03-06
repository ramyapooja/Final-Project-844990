import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
import { AccountService } from 'src/app/Services/account.service';
import { Router } from '@angular/router';
import { Token } from 'src/app/Models/token';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
collapse:boolean=true;
userName:string;
 password:string;
 loginForm:FormGroup;
submitted=false;
role: any;
token:Token;
  constructor(private formbuilder:FormBuilder,private service:AccountService,private router:Router) { }

  ngOnInit() {
    this.loginForm=this.formbuilder.group({
      userName:['',Validators.required],
      password:['',Validators.required],
      role:['']
    });
   
  }
  get f()
{
  return this.loginForm.controls;
}
onSubmit()
{
  this.submitted=true;
  this.Validate();
}
public Validate()
{
  let userName=this.loginForm.value['userName'];
  let password=this.loginForm.value['password'];
  let role=this.loginForm.value['role'];
  this.token=new Token();
  // alert(username)
  // alert(role)
  if(role=='buyer')
  {
    this.service.BuyerLogin(userName,password).subscribe(res=>{
      console.log(res);
      this.token=res;
      localStorage.setItem('buyerId',this.token.buyerId);
      if(this.token.msg=='Success'){
          this.router.navigateByUrl('/buyer');
      }
      else{
        alert('Invalid Credentials');
      }
    });
  }
if(role=='seller')
{
 
this.service.SellerLogin(userName,password).subscribe(res=>{
  console.log(res)
  this.token=res;
  localStorage.setItem('sellerId',this.token.sellerId);
  if(this.token.msg=="Success"){
    this.router.navigateByUrl("/seller")
  }
  else{
    alert('invalid  Credentials');
  }
});

}
if(role=='')
{
if(userName=="Admin" && password=="admin")
{
  this.router.navigateByUrl("/admin");
}
else{
  alert("Invalid credentials");
}
}
}

}
