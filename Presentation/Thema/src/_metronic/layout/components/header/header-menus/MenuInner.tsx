import { useIntl } from 'react-intl'
import { MenuItem } from './MenuItem'
import { MenuInnerWithSub } from './MenuInnerWithSub'
import { MegaMenu } from './MegaMenu'

export function MenuInner() {
  const intl = useIntl()
  return (
    <>
      <MenuItem icon='burger-menu' to='/Dashboard' title='Main Page' />
      <MenuItem icon='calendar' to='/daily-info' title='Daily Info' />
      <MenuItem icon='rocket' to='/apps/user-management/users' title='Near Objects' />
      <MenuItem icon='question-2' to='/apps/user-management/users' title='Curious Page' />
    </>
  )
}
