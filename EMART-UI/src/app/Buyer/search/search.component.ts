import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { BuyerService } from 'src/app/Services/buyer.service';
import { Router } from '@angular/router';
import { Cart } from 'src/app/Models/cart';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  buyerForm:FormGroup;
item:Items;
itemlist:Items[];
itemName:string;
cart:Cart;
  constructor(private builder:FormBuilder,private service:BuyerService,private route:Router) { }

  ngOnInit() {
    this.buyerForm=this.builder.group({
       itemName:['']
       
    });

  }
  Search()
  {
     this.itemName=this.buyerForm.value["itemName"];
    this.service.SearchItems(this.itemName).subscribe(res=>{
        this.itemlist=res;
        console.log(this.itemlist);
  })
}
Buy(item:Items)
{
  localStorage.setItem('item',JSON.stringify(item));
  this.route.navigateByUrl('/buyer/buyproduct');
}
AddtoCart(item:Items)
{
 this.cart=new Cart();
 this.cart.id='C'+Math.round(Math.random()*999);
 this.cart.itemId=item.itemId;
   this.cart.itemName=item.itemName;
   this.cart.categoryId=item.categoryId;
   this.cart.subcategoryId=item.subcategoryId;
   this.cart.sellerId=item.sellerId;
   this.cart.stockNumber=item.stockNumber;
   this.cart.price=item.price;
   this.cart.description=item.description;
   this.cart.remarks=item.remarks;
   this.cart.img=item.img;
   console.log(this.cart);
   this.service.AddtoCart(this.cart).subscribe(res=>{
     console.log("Record added To Cart");
     alert('Item has been Added To Cart');
   })
  }
}
