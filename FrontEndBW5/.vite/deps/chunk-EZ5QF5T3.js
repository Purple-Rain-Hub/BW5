import {
  CardHeaderContext_default
} from "./chunk-HYNCHTJA.js";
import {
  Nav_default,
  useButtonProps,
  useNavItem
} from "./chunk-ISN5TG6K.js";
import {
  NavbarContext_default
} from "./chunk-UKNEREV5.js";
import {
  makeEventKey,
  useEventCallback,
  useUncontrolled
} from "./chunk-MQC4GN3F.js";
import {
  require_classnames,
  require_jsx_runtime,
  useBootstrapPrefix
} from "./chunk-VTSRCESW.js";
import {
  __toESM,
  require_react
} from "./chunk-Q462PRL3.js";

// node_modules/react-bootstrap/esm/Nav.js
var import_classnames3 = __toESM(require_classnames());
var React4 = __toESM(require_react());
var import_react9 = __toESM(require_react());

// node_modules/react-bootstrap/esm/NavItem.js
var React = __toESM(require_react());
var import_classnames = __toESM(require_classnames());
var import_jsx_runtime = __toESM(require_jsx_runtime());
var NavItem = React.forwardRef(({
  className,
  bsPrefix,
  as: Component = "div",
  ...props
}, ref) => {
  bsPrefix = useBootstrapPrefix(bsPrefix, "nav-item");
  return (0, import_jsx_runtime.jsx)(Component, {
    ref,
    className: (0, import_classnames.default)(className, bsPrefix),
    ...props
  });
});
NavItem.displayName = "NavItem";
var NavItem_default = NavItem;

// node_modules/react-bootstrap/esm/NavLink.js
var import_classnames2 = __toESM(require_classnames());
var React3 = __toESM(require_react());

// node_modules/@restart/ui/esm/Anchor.js
var React2 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useCallbackRef.js
var import_react = __toESM(require_react());
function useCallbackRef() {
  return (0, import_react.useState)(null);
}

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useEventListener.js
var import_react2 = __toESM(require_react());
function useEventListener(eventTarget, event, listener, capture = false) {
  const handler = useEventCallback(listener);
  (0, import_react2.useEffect)(() => {
    const target = typeof eventTarget === "function" ? eventTarget() : eventTarget;
    target.addEventListener(event, handler, capture);
    return () => target.removeEventListener(event, handler, capture);
  }, [eventTarget]);
}

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useGlobalListener.js
var import_react3 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useInterval.js
var import_react4 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useRafInterval.js
var import_react5 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useMergeState.js
var import_react6 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useImage.js
var import_react7 = __toESM(require_react());

// node_modules/@restart/ui/node_modules/@restart/hooks/esm/useResizeObserver.js
var import_react8 = __toESM(require_react());

// node_modules/@restart/ui/esm/Anchor.js
var import_jsx_runtime2 = __toESM(require_jsx_runtime());
var _excluded = ["onKeyDown"];
function _objectWithoutPropertiesLoose(r, e) {
  if (null == r) return {};
  var t = {};
  for (var n in r) if ({}.hasOwnProperty.call(r, n)) {
    if (e.indexOf(n) >= 0) continue;
    t[n] = r[n];
  }
  return t;
}
function isTrivialHref(href) {
  return !href || href.trim() === "#";
}
var Anchor = React2.forwardRef((_ref, ref) => {
  let {
    onKeyDown
  } = _ref, props = _objectWithoutPropertiesLoose(_ref, _excluded);
  const [buttonProps] = useButtonProps(Object.assign({
    tagName: "a"
  }, props));
  const handleKeyDown = useEventCallback((e) => {
    buttonProps.onKeyDown(e);
    onKeyDown == null ? void 0 : onKeyDown(e);
  });
  if (isTrivialHref(props.href) || props.role === "button") {
    return (0, import_jsx_runtime2.jsx)("a", Object.assign({
      ref
    }, props, buttonProps, {
      onKeyDown: handleKeyDown
    }));
  }
  return (0, import_jsx_runtime2.jsx)("a", Object.assign({
    ref
  }, props, {
    onKeyDown
  }));
});
Anchor.displayName = "Anchor";
var Anchor_default = Anchor;

// node_modules/react-bootstrap/esm/NavLink.js
var import_jsx_runtime3 = __toESM(require_jsx_runtime());
var NavLink = React3.forwardRef(({
  bsPrefix,
  className,
  as: Component = Anchor_default,
  active,
  eventKey,
  disabled = false,
  ...props
}, ref) => {
  bsPrefix = useBootstrapPrefix(bsPrefix, "nav-link");
  const [navItemProps, meta] = useNavItem({
    key: makeEventKey(eventKey, props.href),
    active,
    disabled,
    ...props
  });
  return (0, import_jsx_runtime3.jsx)(Component, {
    ...props,
    ...navItemProps,
    ref,
    disabled,
    className: (0, import_classnames2.default)(className, bsPrefix, disabled && "disabled", meta.isActive && "active")
  });
});
NavLink.displayName = "NavLink";
var NavLink_default = NavLink;

// node_modules/react-bootstrap/esm/Nav.js
var import_jsx_runtime4 = __toESM(require_jsx_runtime());
var Nav = React4.forwardRef((uncontrolledProps, ref) => {
  const {
    as = "div",
    bsPrefix: initialBsPrefix,
    variant,
    fill = false,
    justify = false,
    navbar,
    navbarScroll,
    className,
    activeKey,
    ...props
  } = useUncontrolled(uncontrolledProps, {
    activeKey: "onSelect"
  });
  const bsPrefix = useBootstrapPrefix(initialBsPrefix, "nav");
  let navbarBsPrefix;
  let cardHeaderBsPrefix;
  let isNavbar = false;
  const navbarContext = (0, import_react9.useContext)(NavbarContext_default);
  const cardHeaderContext = (0, import_react9.useContext)(CardHeaderContext_default);
  if (navbarContext) {
    navbarBsPrefix = navbarContext.bsPrefix;
    isNavbar = navbar == null ? true : navbar;
  } else if (cardHeaderContext) {
    ({
      cardHeaderBsPrefix
    } = cardHeaderContext);
  }
  return (0, import_jsx_runtime4.jsx)(Nav_default, {
    as,
    ref,
    activeKey,
    className: (0, import_classnames3.default)(className, {
      [bsPrefix]: !isNavbar,
      [`${navbarBsPrefix}-nav`]: isNavbar,
      [`${navbarBsPrefix}-nav-scroll`]: isNavbar && navbarScroll,
      [`${cardHeaderBsPrefix}-${variant}`]: !!cardHeaderBsPrefix,
      [`${bsPrefix}-${variant}`]: !!variant,
      [`${bsPrefix}-fill`]: fill,
      [`${bsPrefix}-justified`]: justify
    }),
    ...props
  });
});
Nav.displayName = "Nav";
var Nav_default2 = Object.assign(Nav, {
  Item: NavItem_default,
  Link: NavLink_default
});

export {
  NavItem_default,
  useCallbackRef,
  useEventListener,
  Anchor_default,
  NavLink_default,
  Nav_default2 as Nav_default
};
//# sourceMappingURL=chunk-EZ5QF5T3.js.map
