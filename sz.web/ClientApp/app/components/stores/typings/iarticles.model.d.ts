import { IStore } from './istore.model.d'

export interface IArticle {
    id: number;
    name: string;
    description: string;
    price: number;
    total_in_shelf: number;
    total_in_vault: number;
    store_name: string;
}