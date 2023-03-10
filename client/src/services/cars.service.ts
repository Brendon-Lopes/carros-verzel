import { api } from '../providers/api'

interface IOptions {
  name?: string
  order?: string
  page?: number
  pageSize?: number
  brandName?: string
}

export const getAllCars = async ({
  name = '',
  order = 'desc',
  brandName = '',
  page = 1,
  pageSize = 9,
}: IOptions = {}) => {
  let params: IOptions = { order, page, pageSize }

  if (name !== '') params = { ...params, name }
  if (brandName !== '') params = { ...params, brandName }

  try {
    const { data } = await api.get('/cars', { params })

    return data
  } catch (err) {
    console.log(err)
  }
}
