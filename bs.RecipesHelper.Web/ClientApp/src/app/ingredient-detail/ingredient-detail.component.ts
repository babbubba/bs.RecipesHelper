import { Component, OnInit, Input } from '@angular/core';
import { IngredientDetail } from '../../../Models/Ingredient.model';

@Component({
  selector: 'app-ingredient-detail',
  templateUrl: './ingredient-detail.component.html',
  styleUrls: ['./ingredient-detail.component.css']
})
export class IngredientDetailComponent implements OnInit {

  @Input() IngredientDetail: IngredientDetail;
  constructor() { }

  ngOnInit() {

  }

}
