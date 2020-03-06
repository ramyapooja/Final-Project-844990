import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BuyerService } from 'src/app/Services/buyer.service';
import { Buyer } from 'src/app/Models/buyer';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {
viewprofileForm:FormGroup;
submitted:boolean=false;
buyer:Buyer;
  constructor(private formbuilder:FormBuilder,private service:BuyerService) { 
    
    let id1=localStorage.getItem('buyerId');
    console.log(id1);
    this.service.GetProfile(id1).subscribe(res=>{
      this.buyer=res;
      console.log(this.buyer);
      this.viewprofileForm.patchValue({
        buyerId:this.buyer.buyerId,
        userName:this.buyer.userName,
        password:this.buyer.password,
        emailId:this.buyer.emailId,
        mobileNo:this.buyer.mobileNo,
        createdDateTime:this.buyer.createdDateTime
      })
    })
    }

    ngOnInit() {
      this.viewprofileForm=this.formbuilder.group({
        buyerId:['',Validators.required],
       userName:['',[Validators.required,Validators.pattern('^[a-zA-Z]{3,6}$')]],
        mobileNo:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
       emailId:['',[Validators.required,Validators.email]],
        password:['',[Validators.required,Validators.minLength(6)]],
        createdDateTime:['']
       
  
      });
    }
    onSubmit()
    {
      this.submitted=true;
     
  }
  get f()
  {
    return this.viewprofileForm.controls;
  }
  EditProfile()
{
  this.buyer=new Buyer();
  this.buyer.buyerId=this.viewprofileForm.value["buyerId"];
  this.buyer.userName=this.viewprofileForm.value["userName"];
  this.buyer.password=this.viewprofileForm.value["password"];
  this.buyer.emailId=this.viewprofileForm.value["emailId"];
  this.buyer.mobileNo=this.viewprofileForm.value["mobileNo"];
this.buyer.createdDateTime=this.viewprofileForm.value["createdDateTime"];

  console.log(this.buyer);
  this.service.EditProfile(this.buyer).subscribe(res=>
    {
      console.log('Record Updated');
    })
}


}
