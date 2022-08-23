local UIBaseCtrl = require "UIController/UIBaseCtrl"
local UIBattleCtrl = class("UIBattleCtrl", UIBaseCtrl)

local cavansGroupUI = nil
local loopView = nil
local battleModule = nil
local gmCmdCtrl = nil
local panelMgr = nil
local cacheMsg = nil

function UIBattleCtrl:Awake()
	local moduleMgr = MgrCenter:GetManager(ManagerNames.Module)
	battleModule = moduleMgr:GetModule(ModuleNames.Battle)
	battleModule:Initialize()

	local ctrlMgr = MgrCenter:GetManager(ManagerNames.Ctrl)
	gmCmdCtrl = ctrlMgr:GetCtrl(CtrlNames.GMCmd)

	local panelMgr = MgrCenter:GetManager(ManagerNames.Panel)
	panelMgr:CreatePanel(self, UILayer.Common, UiNames.Battle, self.OnCreateOK)
	logWarn("UIBattleCtrl.Awake--->>")
	---@type BattleMain
	self.battleMain = nil
end

function UIBattleCtrl:Update()

end

--启动事件--
function UIBattleCtrl:OnCreateOK()
	local rect = self.gameObject:GetComponent('RectTransform')
	if rect ~= nil then
		rect.offsetMin = Vector2.zero
		rect.offsetMax = Vector2.zero
	end
	--local loadingUI = self.gameObject.transform:Find("LoadingUI")
	--if loadingUI ~= nil then
	--	cavansGroupUI = loadingUI:GetComponent('CanvasGroup')
	--end
	--
	--self:SetUiLayout()		--设置UI布局--
	--
	--local scrollView = self.gameObject.transform:Find("ScrollViewRoot")
	--if not isnil(scrollView) then
	--	local totalCount = battleModule:GetDataListSize()
	--	loopView = LuaUtil.GetComponent(scrollView.gameObject, ComponentNames.LoopListBox)
	--	loopView:InitListView(self, totalCount, self.OnItemUpdate)
	--
	--	self:HandleCacheMsg()	--处理缓存消息--
	--end
	--self.behaviour:AddClick(self.btn_send, self, self.OnBtnSendClick)
	--self.behaviour:AddEndEdit(self.input_msg, self, self.OnEndEdit)
	--logWarn("OnCreateOK--->>"..self.gameObject.name)


	self.battleMain = require("Battle.BattleMain"):new()
	self.battleMain:Create()
	self.battleMain:TestBattle()
end

--关闭事件--
function UIBattleCtrl:Close()
	if not isnil(loopView) then
		loopView:Dispose()
	end
	panelMgr:ClosePanel(UiNames.Battle)
end

function UIBattleCtrl:Show(isShow)
	self:ShowBottomUI(isShow)
end

return UIBattleCtrl