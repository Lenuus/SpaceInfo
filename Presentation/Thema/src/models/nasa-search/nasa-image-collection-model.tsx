import { string } from "yup";
import { SearchItemResponseDataModel } from "./search-item-data-response-model";
import { ImageItemsModel } from "./nasa-image-items-model";

class NasaSearchImageCollectionModel {

    public version: string = "";
    public href: string = "";
    public items: ImageItemsModel[] = []
}

export { NasaSearchImageCollectionModel }