---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by miao.
--- DateTime: 8/22/22 9:16 PM
---



local BuffBase = require "Battle.Buff.BuffBase"
-- 属性
---@class AttBase : BuffBase
local AttBase = class("SneakBuff", BuffBase)

function AttBase:initialize()
    self.id = 2
end

return AttBase