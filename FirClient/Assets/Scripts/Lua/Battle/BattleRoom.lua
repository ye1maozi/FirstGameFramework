---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by miao.
--- DateTime: 8/22/22 10:31 PM
---


---@class BattleRoom
local BattleRoom = class("BattleRoom")


function BattleRoom:initialize(roomId)
    self.roomId = roomId
    self.fieldBattle = nil
    self.preparePool = nil
end

function BattleRoom:Create(teamsInfo)
    log("[Room] create!")
    self.preparePool = require("Battle.PreparePool"):new(self)
    self.fieldBattle = require("Battle.BattleField"):new(teamsInfo)
end

function BattleRoom:Destroy()

end


function BattleRoom:Update(deltaTime)
    --update buff
    self.fieldBattle:Update(deltaTime)
    -- update atb
    self.preparePool:Update(deltaTime)
end

function BattleRoom:LateUpdate(deltaTime)
    --do action
    self.fieldBattle:LateUpdate(deltaTime)

     self:CheckBattleEnd()
end

function BattleRoom:CheckBattleEnd()

end


function BattleRoom:ParseMessage(message)
    if message.cmd == BattleMessageId.UseCard then
        if self:IsHeroCard(message.cardId) then
            self.preparePool:Add(message.cardId,message.teamId,message.pos)
        end
    end
end

function BattleRoom:IsHeroCard(cardId)
    return true
end

function BattleRoom:EnterField(entity)
    self.fieldBattle:AddEntity(entity)
end

function BattleRoom:DoAction(entity)
    entity:DoAction()
end

function BattleRoom:GetNext(teamId, pos)
    local py = pos.y
    if self:IsLeftTeam(teamId) then
        py = py + 2
    else
        py = py - 2
    end
    if py < 0 or py > 18 then
        py = pos.y
    end
    pos.y = py
    return pos
end

function BattleRoom:IsLeftTeam(teamId)

end

return BattleRoom