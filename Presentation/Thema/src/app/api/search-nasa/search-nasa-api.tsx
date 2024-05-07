import axios from "axios";
import { NasaSearchRequestModel } from "../../../models/nasa-search/nasa-search-request-model";
import { PagedResponseModel } from "../../../models/paged-response-model";
import ServiceResponse from "../../../models/service-response";
import { SearchItemResponseDataModel } from "../../../models/nasa-search/search-item-data-response-model";
import { NasaImageResponseModel } from "../../../models/nasa-search/nasa-image-response-model";
import { DataImageRequestModel } from "../../../models/nasa-search/data-image-request-model";


const API_URL = import.meta.env.VITE_APP_API_URL;
export function getSearchItems(request: NasaSearchRequestModel) {
    var response = axios.post<ServiceResponse<PagedResponseModel<SearchItemResponseDataModel>>>(API_URL + "/search-nasa-item", request);
    return response;
}
export  function getSearchedItemsImage(request: DataImageRequestModel) {
    try {
        const response = axios.post<ServiceResponse<NasaImageResponseModel>>(API_URL + "/nasa-item-images", request);
        return response;
    } catch (error) {
        console.error("gönderilemedi", error);
        throw error;
    }
}
