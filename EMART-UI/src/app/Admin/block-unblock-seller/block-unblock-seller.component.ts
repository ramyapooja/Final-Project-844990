import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
@Component({
  selector: 'app-block-unblock-seller',
  templateUrl: './block-unblock-seller.component.html',
  styleUrls: ['./block-unblock-seller.component.css']
})
export class BlockUnblockSellerComponent implements OnInit {
  sid:string;
  blockForm:FormGroup;
  submitted:boolean=false;
  constructor(private formbuilder:FormBuilder) { }

  ngOnInit() {
    this.blockForm=this.formbuilder.group({
      sid:['',Validators.required]
    });
  }
  onSubmit()
  {
    this.submitted=true;
    if(this.blockForm.valid)
    {
      console.log(JSON.stringify(this.blockForm.value));
    }
  }
  get f()
{
  return this.blockForm.controls;
}
}
