import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { Home, Login } from '../pages'

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/login' element={<Login />} />
        <Route path='*' element={<h1>404 Page Not Found</h1>} />
      </Routes>
    </BrowserRouter>
  )
}
