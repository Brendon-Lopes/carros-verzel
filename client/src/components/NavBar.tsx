import { NavLink } from 'react-router-dom'
import { RiAdminLine } from 'react-icons/ri'

export function NavBar() {
  return (
    <nav className='flex justify-center h-20 bg-slate-100 drop-shadow-md px-4'>
      <div className='w-full max-w-7xl flex justify-between items-center text-gray-700'>
        <NavLink to={'/'}>
          <h1 className='hover:text-black transition-all text-lg'>
            Verzel Cars
          </h1>
        </NavLink>

        <NavLink to={'/login'}>
          <button
            className='hover:text-black transition-all flex items-center gap-2 text-lg'
            onClick={() => {
              console.log('Login')
            }}
          >
            <RiAdminLine />
            Login
          </button>
        </NavLink>
      </div>
    </nav>
  )
}
