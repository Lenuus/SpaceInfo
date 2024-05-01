import axios from "axios";
import { NasaSearchRequestModel } from "../../../models/nasa-search/nasa-search-request-model";
import { PagedResponseModel } from "../../../models/paged-response-model";
import { NasaSearchReponseModel } from "../../../models/nasa-search/nasa-search-response-model";
import ServiceResponse from "../../../models/service-response";
import { SearchItemDataModel } from "../../../models/nasa-search/search-item-data-response-model";


const API_URL = import.meta.env.VITE_APP_API_URL;
export function getSearchItems(request: NasaSearchRequestModel) {
    var response = axios.post<ServiceResponse<PagedResponseModel<SearchItemDataModel>>>(API_URL + "/search-nasa-item", request);
    return response;
}
