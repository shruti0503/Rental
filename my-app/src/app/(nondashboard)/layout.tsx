"use client"
import Navbar from "@/components/Navbar"
import { NAVBAR_HEIGHT } from "@/lib/constants"

const Layout=({children}:{children:React.ReactNode})=>{

    return (
        <div className="h-full w-full">
            <main className={`h-full flex w-full flex-col`}
              style={{paddingTop:`${NAVBAR_HEIGHT}px`}}>
                {children}
              </main>

        </div>
    )
}

export default Layout