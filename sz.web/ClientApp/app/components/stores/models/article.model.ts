import { IArticle } from '../typings/iarticles.model.d'
import { IStore }  from '../typings/istore.model.d'

export class Article implements IArticle {
    id: number;
    name: string;
    description: string;
    price: number;
    total_in_shelf: number;
    total_in_vault: number;
    store_name: string;
    constructor() {
        this.id = 0;
        this.name = "";
        this.description = "";
        this.price = 0;
        this.total_in_shelf = 0;
        this.total_in_vault = 0;
        this.store_name = "";
    }
}