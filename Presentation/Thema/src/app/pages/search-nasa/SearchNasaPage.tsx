import React, { FC, useEffect, useState } from 'react';
import { useIntl } from 'react-intl';
import { PageTitle } from '../../../_metronic/layout/core';
import { getSearchItems } from '../../api/search-nasa/search-nasa-api';
import { NasaSearchRequestModel } from '../../../models/nasa-search/nasa-search-request-model';
import { SearchItemResponseDataModel } from '../../../models/nasa-search/search-item-data-response-model';

export const SearchNasaPage: FC = () => {
  const intl = useIntl();
  const [currentPageIndex, setCurrentPageIndex] = useState(0);
  const [currentPageSize, setCurrentPageSize] = useState(20);
  const [refreshData, setRefreshData] = useState(false);
  const [totalPage, setTotalPage] = useState(0);
  const [currentSearchQuery, setCurrentSearchQuery] = useState<string>("");
  const [searchData, setSearchData] = useState<SearchItemResponseDataModel[]>([]);
  const [isOpen, setIsOpen] = useState<boolean[]>(Array(searchData.length).fill(false));
  const [dataReady, setDataReady] = useState<boolean>(false);

  const toggleMenu = (index: number) => {
    const newIsOpen = Array(searchData.length).fill(false);
    newIsOpen[index] = !isOpen[index];

    setIsOpen(newIsOpen);
  };

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
      setIsOpen(Array(response.data.data.data.length).fill(false));
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
            <div>
              {searchData.map((item, index) => (
                <div key={index} onClick={() => toggleMenu(index)} className="my-2">
                  <div className='container border'>
                    <h1 className={isOpen[index] ? 'text-danger' : 'text-primary'}>{item.title}</h1>
                  </div>
                  {isOpen[index] && (
                    <div className="card bg-light shadow-sm">
                      <div className="card-body card-scroll h-200px">
                        <h2 className='text-success'>{item.description}</h2>
                      </div>
                    </div>
                  )}
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>

    </>
  );
};
