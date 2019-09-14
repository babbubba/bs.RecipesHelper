import { IngredientCategoryInfo } from './IngredientCategory.model';
import { IngredientVariantInfo } from './IngredientVariant.model';

export class IngredientInfo {
  public id: string;
  public name: string;
  public isEnabled: boolean;
}

export class IngredientDetail  {
  public id: string;
  public name: string;
  public description: string;
  public isEnabled: boolean;
  public categories: IngredientCategoryInfo[];
  public variants: IngredientVariantInfo[];
}

