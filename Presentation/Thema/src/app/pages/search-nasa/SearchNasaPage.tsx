import React, { FC, useEffect, useState } from 'react';
import { useIntl } from 'react-intl';
import { PageTitle } from '../../../_metronic/layout/core';
import { getSearchItems, getSearchedItemsImage } from '../../api/search-nasa/search-nasa-api';
import { NasaSearchRequestModel } from '../../../models/nasa-search/nasa-search-request-model';
import { SearchItemResponseDataModel } from '../../../models/nasa-search/search-item-data-response-model';
import { WithChildren } from '../../../_metronic/helpers';
import { ImageItemsModel } from '../../../models/nasa-search/nasa-image-items-model';
import { DataImageRequestModel } from '../../../models/nasa-search/data-image-request-model';
import { auto } from '@popperjs/core';

export const SearchNasaPage: FC = () => {
  const intl = useIntl();
  const [currentPageIndex, setCurrentPageIndex] = useState(0);
  const [currentPageSize, setCurrentPageSize] = useState(20);
  const [refreshData, setRefreshData] = useState(false);
  const [totalPage, setTotalPage] = useState(0);
  const [currentSearchQuery, setCurrentSearchQuery] = useState<string>("");
  const [searchData, setSearchData] = useState<SearchItemResponseDataModel[]>([]);
  const [dataReady, setDataReady] = useState<boolean>(false);
  const [openedItem, setOpenedItem] = useState<string>();


  const renderPaginationButtons = () => {
    var buttons = [];
    if (totalPage > 10) {
      var firstIndex = currentPageIndex > 5 ? currentPageIndex - 4 : 0;
      var lastIndex = currentPageIndex > 5 ? currentPageIndex + 4 > totalPage ? totalPage : currentPageIndex + 4 : 10;
      for (var i = firstIndex; i < lastIndex; i++) {
        var pageName = "page_" + i;
        buttons.push(
          <>
            <li key={pageName} className={"page-item " + pageName + " " + (i == currentPageIndex && "active")}><button className="page-link" value={i} onClick={(e) => {
              setCurrentPageIndex(parseInt(e.currentTarget.value));
              setRefreshData(true);
            }}>{(i + 1)}</button></li>
          </>);
      }
    }
    else {
      for (var i = 0; i < totalPage; i++) {
        var pageName = "page_" + i;
        buttons.push(
          <>
            <li key={pageName} className={"page-item " + (i == currentPageIndex && "active")}><button className="page-link" value={i} onClick={(e) => {
              setCurrentPageIndex(parseInt(e.currentTarget.value));
              setRefreshData(true);
            }}>{(i + 1)}</button></li>
          </>);
      }
    }
    return (<>{buttons}</>);
  }


  const search = async () => {
    try {
      setDataReady(false);
      const requestData = new NasaSearchRequestModel();
      requestData.pageIndex = currentPageIndex;
      requestData.pageSize = currentPageSize;
      requestData.search = currentSearchQuery;
      const response = await getSearchItems(requestData);
      setSearchData(response.data.data.data);
      setTotalPage(response.data.data.totalPage);
      setRefreshData(false);
      setDataReady(true);
    } catch (error) {
      console.error("Error while fetching data:", error);
    }
  };

  useEffect(() => {
    search();
  }, []);

  useEffect(() => {
    if (refreshData) {
      search();
    }
  }, [refreshData]);

  return (
    <>
      <PageTitle breadcrumbs={[]}>Curious Page</PageTitle>
      <div className={!dataReady ? "modal-body overlay overlay-block" : ""}>
        <div className='row justify-content-center '>
          <div className='col-md-6'>
            <div className="mb-10">
              <label className="form-label">Search by keyword</label>
              <div style={{ display: "flex" }}>
                <input type="text" className="form-control form-control-solid" value={currentSearchQuery} onChange={(e) => setCurrentSearchQuery(e.target.value)} placeholder="Search by keyword" style={{ marginRight: "10px" }} />
                <button className="btn btn-success" type="button" onClick={() => {
                  setCurrentPageIndex(0);
                  setRefreshData(true);
                }}>Search</button>
              </div>
            </div>
            <div className="accordion accordion-icon-collapse" id="kt_accordion_3">
              {searchData.map((item, index) => (
                <SearchItemComponent key={item.nasa_id} searchItem={item} isOpen={openedItem == item.nasa_id} onClicked={setOpenedItem} />
              ))}
            </div>
          </div>
        </div>
        <div>
          <ul className="pagination">
            <li className={"page-item previous" + (currentPageIndex == 0 ? "disabled" : "")}>
              <button className="page-link" onClick={() => {
                if (currentPageIndex > 1) {
                  setCurrentPageIndex(currentPageIndex - 1);
                  setRefreshData(true);
                }
              }}>
                <i className="previous"></i>
              </button>
            </li>
            {renderPaginationButtons()}
            <li className={"page-item next" + (currentPageIndex == totalPage ? "disabled" : "")} onClick={() => {
              if (currentPageIndex < totalPage) {
                setCurrentPageIndex(currentPageIndex + 1);
                setRefreshData(true);
              }
            }}>
              <button className="page-link"><i className="next"></i></button>
            </li>
          </ul>
        </div>
      </div>

    </>
  );
};

type Props = {
  searchItem: SearchItemResponseDataModel,
  onClicked: any,
  isOpen: boolean
}

const SearchItemComponent: FC<Props & WithChildren> = ({ searchItem, onClicked, isOpen }) => {
  const [media, setMediaItem] = useState<ImageItemsModel[]>([]);

  const getMedias = async () => {
    try {
      const requestData = new DataImageRequestModel();
      requestData.NasaId = searchItem.nasa_id;
      const response = await getSearchedItemsImage(requestData);
      setMediaItem(response.data.data.collection.items);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div key={searchItem.nasa_id} className="mb-5">
      <div className="accordion-header py-3 d-flex" data-bs-toggle="collapse" data-bs-target={`${searchItem.nasa_id}`} onClick={() => { !isOpen ? onClicked(searchItem.nasa_id) : onClicked(""); }}>
        <span className="accordion-icon">
          <i className="ki-duotone ki-plus-square fs-3 accordion-icon-off"><span className="path1"></span><span className="path2"></span><span className="path3"></span></i>
          <i className="ki-duotone ki-minus-square fs-3 accordion-icon-on"><span className="path1"></span><span className="path2"></span><span className="path3"></span></i>
        </span>
        <h3 className="fs-4 fw-semibold mb-0 ms-4">{searchItem.title}</h3>
      </div>
      <div id={`item_${searchItem.nasa_id}`} className={`fs-6 collapse ps-10${isOpen ? ' show' : ''}`} data-bs-parent="#kt_accordion_3">
        {searchItem.description}
        <div className='row'>
          <i className="ki-duotone ki-abstract-6 text-muted fs-2x" data-bs-toggle="modal" data-bs-target={`#kt_modal_scrollable_${searchItem.nasa_id}`} onClick={getMedias}>
          </i>
        </div>
      </div>
      <div className="modal fade" tabIndex={-1} id={`kt_modal_scrollable_${searchItem.nasa_id}`}>
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">Modal title</h5>
              <div className="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal">
                <i className="ki-duotone ki-cross fs-2x"><span className="path1"></span><span className="path2"></span></i>
              </div>
            </div>
            <div className="modal-body" style={{ minHeight: auto }}>
              <div id={`kt_carousel_1_carousel_${searchItem.nasa_id}`} className="carousel carousel-custom slide" data-bs-ride="carousel" data-bs-interval="8000">
                <div className="d-flex align-items-center justify-content-between flex-wrap">
                  <span className="fs-4 fw-bold pe-2">{searchItem.title}</span>
                  <ol className="p-0 m-0 carousel-indicators carousel-indicators-dots">
                    {media.filter(item => item.href.includes("jpg")).map((item, index) => (
                      <li key={index} data-bs-target={`#kt_carousel_1_carousel_${searchItem.nasa_id}`} data-bs-slide-to={index} className={index === 0 ? 'ms-1 active' : ""}></li>
                    ))}
                  </ol>
                </div>
                <div className="carousel-inner pt-8 ">
                  {media.filter(item => item.href.includes("jpg")).map((item, index) => (
                    <div key={index} className={`carousel-item${index === 0 ? ' active' : ''}`}>
                      <img src={item.href} alt={`Image ${index}`} style={{ objectFit: 'cover', width: '100%', height: 'auto', display: 'block', margin: '0 auto' }} />
                    </div>
                  ))}
                </div>
              </div>
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-light" data-bs-dismiss="modal">Close</button>
              <button type="button" className="btn btn-primary">Save changes</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    /* <div key={searchItem.nasa_id} className="my-2" onClick={() => { onClicked(searchItem.nasa_id); }}>
       <div className='container border'>
         <h1 className={isOpen ? 'text-danger' : 'text-primary'}>{searchItem.title}</h1>
       </div>
       {isOpen && <>
         <div className="card bg-light shadow-sm">
           <div className="card-body card-scroll h-200px">
             <h2 className='text-success'>{searchItem.description}</h2>
           </div>
         </div>
       </>}
     </div>*/
  );
}