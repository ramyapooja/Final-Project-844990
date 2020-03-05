import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { BuyerService } from 'src/app/Services/buyer.service';
import { Router } from '@angular/router';

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
  constructor(private builder:FormBuilder,private service:BuyerService) { }

  ngOnInit() {
    this.buyerForm=this.builder.group({
       itemName:[''],
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
}
