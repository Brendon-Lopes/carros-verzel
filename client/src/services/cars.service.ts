import { api } from '../providers/api'
import { type ICreateCarFormData } from '../validations/create-car.validation'

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

export const createCar = async (car: ICreateCarFormData, token: string) => {
  const payload = {
    name: car.name,
    model: car.model,
    year: car.year,
    brandId: car.brand,
    price: car.price,
    imageUrl: car.imageUrl,
  }

  console.log({ payload })

  try {
    const { data } = await api.post('/cars', payload, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })

    return data
  } catch (err) {
    return false
  }
}

export const deleteCar = async (carId: string, token: string) => {
  try {
    const { data } = await api.delete(`/cars/${carId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })

    return data
  } catch (err) {
    return false
  }
}

export const editCar = async (
  carId: string,
  car: ICreateCarFormData,
  token: string
) => {
  const payload = {
    name: car.name,
    model: car.model,
    year: car.year,
    price: car.price,
    imageUrl: car.imageUrl,
  }

  try {
    const { data } = await api.put(`/cars/${carId}`, payload, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })

    return data
  } catch (err) {
    return false
  }
}
