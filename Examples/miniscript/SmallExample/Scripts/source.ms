baseX = 20
baseY = 0
size = 48

border "GREEN"

while true 
    cls "BLUE"

    shiftX = cos(time) * 8
    shiftY = sin(time) * 8
    for x in range(0, size-1)
        for y in range(0, size-1)
            setPixel baseX + x + shiftX, baseY + y + shiftY, x * y
        end for
    end for

    drawText "Hello world!"
    drawText "MiniScript forever! =)", 10, 55, "ORANGE"

    yield
end while