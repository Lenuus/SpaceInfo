import { FC } from 'react'
import { useIntl } from 'react-intl'
import { PageTitle } from '../../../_metronic/layout/core'
import DailyInfoComponent from '../../modules/spaceınfo/DailyInfoComponent'
import { DailyInfoModel } from '../../../models/daily-info-model'
import { date } from 'yup'



const DailyInfoPage = () => {
  const intl = useIntl()
  const dailyInfo= new DailyInfoModel();
  dailyInfo.CopyRight="";
  dailyInfo.HdUrl="https://apod.nasa.gov/apod/image/1509/shark_toet_1980.jpg";
  dailyInfo.Id="";
  dailyInfo.Explanation="Güzel manzara";
  dailyInfo.MediaType="jpg";
  dailyInfo.Title="Güzel Görüntü";
  dailyInfo.DateTime= new Date();
  dailyInfo.CopyRight="Copyright"

  return (
    <>
      <PageTitle breadcrumbs={[]}>Daily Info</PageTitle>
      <DailyInfoComponent dailyinfo={dailyInfo}  />
    </>
  )
}

export { DailyInfoPage }
