import { FC, useEffect, useState } from 'react'
import { useIntl } from 'react-intl'
import { PageTitle } from '../../../_metronic/layout/core'
import DailyInfoComponent from '../../modules/spaceınfo/DailyInfoComponent'
import { DailyInfoResponseModel } from '../../../models/daily-info/daily-info-response-model'
import { date } from 'yup'
import { getDailyInfo } from '../../api/daily-info/daily-info-api'
import { resolve } from 'path'



const DailyInfoPage = () => {
  const intl = useIntl()
  const [dataReady, setDataReady] = useState<boolean>(false);
  const [DailyInfo, SetDailyInfo] = useState<DailyInfoResponseModel>();
  useEffect(() => {
    setDataReady(false);
    getDailyInfo().then((resolve) => {
      SetDailyInfo(resolve.data.data)
    });
    const timeout = setTimeout(() => {
      setDataReady(true);
    }, 2000);
  }, [])

  return (
    <>
      <PageTitle breadcrumbs={[]}>Daily Info</PageTitle>
      <div className={!dataReady ? "row modal-body overlay overlay-block" : "row "}>
        <DailyInfoComponent dailyinfo={DailyInfo} />
      </div>
    </>
  )
}

export { DailyInfoPage }
