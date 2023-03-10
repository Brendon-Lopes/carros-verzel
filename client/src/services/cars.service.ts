import { api } from '../providers/api'

export const getAllCars = async () => {
  try {
    const { data } = await api.get('/cars', {
      params: {
        order: 'desc',
      },
    })

    return data
  } catch (err) {
    console.log(err)
  }
}
