---
----- Generated by EmmyLua(https://github.com/EmmyLua)
----- Created by miaowenjie.
----- DateTime: 8/22/22 9:10 PM
-----


---@class SpellBase
local SpellBase = class("SpellBase")

function SpellBase:initialize()
    self.cost = 0   --消耗
end

return SpellBase