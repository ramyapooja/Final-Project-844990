import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from "@angular/forms";
@Component({
  selector: 'app-block-unblock-buyer',
  templateUrl: './block-unblock-buyer.component.html',
  styleUrls: ['./block-unblock-buyer.component.css']
})
export class BlockUnblockBuyerComponent implements OnInit {
  bid:string;
  blockForm:FormGroup;
  submitted:boolean=false;
  constructor(private formbuilder:FormBuilder) { }

  ngOnInit() {
    this.blockForm=this.formbuilder.group({
      bid:['',Validators.required]
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
