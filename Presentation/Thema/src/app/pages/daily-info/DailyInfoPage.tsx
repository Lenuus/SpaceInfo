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
  const [DailyInfo, SetDailyInfo] = useState();
  useEffect(() => {
    getDailyInfo().then((resolve) => {
      SetDailyInfo(resolve.data.data)
    });
  }, [])

  return (
    <>
      <PageTitle breadcrumbs={[]}>Daily Info</PageTitle>
      <div className='row'>
          <DailyInfoComponent dailyinfo={DailyInfo} />
      </div>
    </>
  )
}

export { DailyInfoPage }
