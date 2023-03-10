import { api } from '../providers/api'

export const getAllBrands = async () => {
  try {
    const { data } = await api.get('/brands')

    return data
  } catch (err) {
    console.log(err)
  }
}
