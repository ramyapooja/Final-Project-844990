import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BuyerService } from 'src/app/Services/buyer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buy-product',
  templateUrl: './buy-product.component.html',
  styleUrls: ['./buy-product.component.css']
})
export class BuyProductComponent implements OnInit {

  isShow:boolean=true;
  item:Items;
  itemlist:Items[];
  buyerForm:FormGroup;
  constructor(private formbuilder:FormBuilder,private service:BuyerService,private route:Router) { }

  ngOnInit() {
    this.buyerForm=this.formbuilder.group({
      img:[''],
      itemName:[''],
      price:['']
    });
  }
  Search()
  {
    this.isShow=!this.isShow;
    let name=this.buyerForm.value["itemName"];
    this.service.SearchItems(name).subscribe(res=>{
      this.itemlist=res;
      console.log(this.item);
     
  })
  }

}
