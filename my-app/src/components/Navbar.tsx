import { NAVBAR_HEIGHT } from '@/lib/constants'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'
import { Button } from './ui/button'
import Logo from './Logo'

const Navbar = () => {
  return (
    <div  className="fixed top-0 left-0 w-full z-50 shadow-xl"
    style={{ height: `${NAVBAR_HEIGHT}px` }}>
        <div className="flex justify-between items-center w-full py-3 px-8  text-white">
            <Link
              href="/"
              className="cursor-pointer hover:!text-primary-300"
              scroll={false}>
                <div className='flex items-center gap-3'>
                    <Logo />
                </div>

            </Link>

            <div className="flex items-center gap-5">
          <Link href="/signin">
                <Button
                  variant="outline"
                  className="text-black border-black bg-transparent hover:bg-black hover:text-primary-700 rounded-lg"
                >
                  Sign In
                </Button>
              </Link>
              <Link href="/signup">
                <Button
                  variant="secondary"
                  className="text-white bg-black hover:bg-white hover:text-primary-700 rounded-lg"
                >
                  Sign Up
                </Button>
              </Link>
        </div>
            
        </div>
        {/* <p className="text-primary-200 hidden md:block">
              Discover your perfect rental apartment with our advanced search
        </p> */}
       
    </div>
  )
}

export default Navbar