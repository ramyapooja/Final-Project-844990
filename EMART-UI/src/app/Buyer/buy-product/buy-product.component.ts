import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BuyerService } from 'src/app/Services/buyer.service';
import { Router } from '@angular/router';
import { TransactionHistory } from 'src/app/Models/transaction-history';
import { Cart } from 'src/app/Models/cart';
import { timingSafeEqual } from 'crypto';

@Component({
  selector: 'app-buy-product',
  templateUrl: './buy-product.component.html',
  styleUrls: ['./buy-product.component.css']
})
export class BuyProductComponent implements OnInit {
  item:Items;
  itemlist:Items[];
  cart:Cart;
  buyerForm:FormGroup;
  tobj:TransactionHistory;
  submitted:boolean=false;
  constructor(private formbuilder:FormBuilder,private service:BuyerService,private route:Router) { }

  ngOnInit() {
    this.buyerForm=this.formbuilder.group({
      
    numberOfItems:['',Validators.required],
    transactionType:[''],
      dateTime:['',Validators.required],
      remarks:['',Validators.required],
      cardnumber:['',Validators.required],
      cvv:['',Validators.required],
      ed:['',Validators.required],
      name:['',Validators.required]
    });
    this.item=JSON.parse(localStorage.getItem('item'));
    console.log(this.item);
    console.log(this.item.itemId);
    
  }
  onSubmit()
  {
    this.submitted=true;
    if(this.buyerForm.valid)
    {
      this.Purchase();
    }
    
    
  }
 Purchase()
 {

   this.tobj=new TransactionHistory();
   this.tobj.id='T'+Math.floor(Math.random()*1000);
   this.tobj.transactionId=this.tobj.id;
   this.tobj.buyerId=localStorage.getItem('buyerId');
   this.tobj.sellerId=this.item.sellerId;
   this.tobj.numberOfItems=this.buyerForm.value['numberOfItems'];
   this.tobj.itemId=this.item.itemId;
   this.tobj.transactionType=this.buyerForm.value['transactionType'];
   this.tobj.dateTime=this.buyerForm.value['dateTime'];
   this.tobj.remarks=this.buyerForm.value['remarks'];
   console.log(this.tobj);
     this.service.BuyItem(this.tobj).subscribe(res=>{
       console.log("Purchase was Sucessfull");
       alert('Purchase Done Successfully');
     })


 }
 get f()
 {
   return this.buyerForm.controls;
 }

}
