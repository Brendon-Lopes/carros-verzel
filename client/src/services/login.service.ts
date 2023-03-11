import { api } from '../providers/api'

export const login = async (email: string, password: string) => {
  try {
    const { data } = await api.post('/auth/login', {
      email,
      password,
    })

    return data
  } catch (err: any) {
    console.log(err)
    if (err.response.status === 400) {
      return false
    }
  }
}
