---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by miao.
--- DateTime: 8/19/22 12:02 AM
---

---@class BuffBase
---@field id number
local BuffBase = class("BuffBase")

function BuffBase:initialize(...)
    self.id = 0
    log("test BuffBase")

end

function BuffBase:Execute()
    log("test execute")
end

return BuffBase